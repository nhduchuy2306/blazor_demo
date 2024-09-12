using AutoMapper;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Dtos;
using ServerLibrary.Models;
using ServerLibrary.Repositories;

public class SalesInvoiceService : ISalesInvoiceService
{
    private readonly SalesInvoiceRepository _salesInvoiceRepository;
    private readonly InvoiceDetailRepository _invoiceDetailRepository;
    private readonly WarehouseRepository _warehouseRepository;
    private readonly WarehouseProductRepository _warehouseProductRepository;
    private readonly IMapper _mapper;

    public SalesInvoiceService(
        SalesInvoiceRepository salesInvoiceRepository,
        InvoiceDetailRepository invoiceDetailRepository,
        WarehouseRepository warehouseRepository,
        WarehouseProductRepository warehouseProductRepository,
        IMapper mapper
    )
    {
        _salesInvoiceRepository = salesInvoiceRepository;
        _invoiceDetailRepository = invoiceDetailRepository;
        _warehouseRepository = warehouseRepository;
        _warehouseProductRepository = warehouseProductRepository;
        _mapper = mapper;
    }

    public IEnumerable<SalesInvoiceDTO> GetAll()
    {
        var salesInvoices = _salesInvoiceRepository.GetAll();
        return _mapper.Map<IEnumerable<SalesInvoiceDTO>>(salesInvoices);
    }

    public SalesInvoiceDTO GetById(int salesInvoiceId)
    {
        var salesInvoice = _salesInvoiceRepository.GetById(salesInvoiceId);
        if (salesInvoice == null)
        {
            throw new KeyNotFoundException($"Sales invoice with id {salesInvoiceId} not found");
        }

        return _mapper.Map<SalesInvoiceDTO>(salesInvoice);
    }

    public void Create(SalesInvoiceInputDTO salesInvoiceInputDTO)
    {
        var invoiceDetails = salesInvoiceInputDTO.InvoiceDetails;
        var salesInvoice = new SalesInvoice
        {
            InvoiceNumber = Guid.NewGuid().ToString(),
            InvoiceDate = DateOnly.FromDateTime(DateTime.Now),
            CustomerId = salesInvoiceInputDTO.CustomerId,
            TotalAmount = salesInvoiceInputDTO.TotalAmount,
        };
        int invoiceId = _salesInvoiceRepository.Create(salesInvoice);

        foreach (var saleDetail in invoiceDetails)
        {
            var invoiceDetail = new InvoiceDetail
            {
                InvoiceId = invoiceId,
                WarehouseId = saleDetail.WarehouseId,
                ProductId = saleDetail.ProductId,
                Quantity = saleDetail.Quantity,
                UnitPrice = saleDetail.UnitPrice,
                Total = saleDetail.Total,
            };
            _invoiceDetailRepository.Create(invoiceDetail);

            var warehouseProduct = _warehouseProductRepository.GetById(saleDetail.WarehouseId, saleDetail.ProductId);

            if (warehouseProduct != null)
            {
                warehouseProduct.StockQuantity -= saleDetail.Quantity;
                _warehouseProductRepository.Update(warehouseProduct);
            }
        }
    }

    public void Update(int salesInvoiceId, SalesInvoiceInputDTO salesInvoiceInputDTO)
    {
        var salesInvoice = _mapper.Map<SalesInvoice>(salesInvoiceInputDTO);
        salesInvoice.InvoiceId = salesInvoiceId;
        _salesInvoiceRepository.Update(salesInvoice);
    }

    public void Delete(int salesInvoiceId)
    {
        var salesInvoice = _salesInvoiceRepository.GetById(salesInvoiceId);
        if (salesInvoice == null)
        {
            throw new KeyNotFoundException($"Sales invoice with id {salesInvoiceId} not found");
        }

        _salesInvoiceRepository.Delete(salesInvoice);
    }

    public IEnumerable<InvoiceDetailDTO> GetInvoiceDetailsByInvoiceId(int invoiceId)
    {
        var invoiceDetails = _salesInvoiceRepository.GetInvoiceDetailsByInvoiceId(invoiceId);
        if (invoiceDetails == null)
        {
            throw new KeyNotFoundException($"Invoice details with invoice id {invoiceId} not found");
        }
        return _mapper.Map<IEnumerable<InvoiceDetailDTO>>(invoiceDetails);
    }

    public IEnumerable<SalesInvoiceDTO> GetSalesByCustomerId(int customerId)
    {
        var invoices = _salesInvoiceRepository.GetSalesByCustomerId(customerId);
        return _mapper.Map<IEnumerable<SalesInvoiceDTO>>(invoices);
    }

    public IEnumerable<SalesPerMonthDto> GetSalesPerMonths()
    {
        var salesPerMonths = _salesInvoiceRepository.GetSalesPerMonths();
        return salesPerMonths;
    }

    public IEnumerable<SalesInvoiceDTO> GetSalesInvoicesData(DateOnly fromDate, DateOnly toDate)
    {
        var salesInvoices = _salesInvoiceRepository.GetSalesInvoicesData(fromDate, toDate);
        return _mapper.Map<IEnumerable<SalesInvoiceDTO>>(salesInvoices);
    }

    public byte[] GenerateExcelReport(IEnumerable<SalesInvoiceDTO> salesInvoices)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Sales Report");

        worksheet.Cell(1, 1).Value = "Invoice Number";
        worksheet.Cell(1, 2).Value = "Invoice Date";
        worksheet.Cell(1, 3).Value = "Customer Name";
        worksheet.Cell(1, 4).Value = "Total Amount";

        int row = 2;
        foreach (var invoice in salesInvoices)
        {
            worksheet.Cell(row, 1).Value = invoice.InvoiceNumber;
            worksheet.Cell(row, 2).Value = invoice.InvoiceDate.ToString("yyyy-MM-dd");
            worksheet.Cell(row, 3).Value = invoice.CustomerName ?? "";
            worksheet.Cell(row, 4).Value = invoice.TotalAmount;
            row++;
        }

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }
}