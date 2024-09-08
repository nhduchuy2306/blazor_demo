using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Dtos;
using ServerLibrary.Models;
using ServerLibrary.Repositories;

public class SalesInvoiceService : ISalesInvoiceService
{
    private readonly SalesInvoiceRepository _salesInvoiceRepository;
    private readonly IMapper _mapper;

    public SalesInvoiceService(SalesInvoiceRepository salesInvoiceRepository, IMapper mapper)
    {
        _salesInvoiceRepository = salesInvoiceRepository;
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
        var salesInvoice = _mapper.Map<SalesInvoice>(salesInvoiceInputDTO);
        _salesInvoiceRepository.Create(salesInvoice);
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
}