using AutoMapper;
using ServerLibrary.Dtos;
using ServerLibrary.Models;
using ServerLibrary.Repositories;

namespace ServerLibrary.Services.impl;

public class InvoiceDetailService : IInvoiceDetailService
{
    private readonly InvoiceDetailRepository _invoiceDetailRepository;
    private readonly IMapper _mapper;

    public InvoiceDetailService(InvoiceDetailRepository invoiceDetailRepository, IMapper mapper)
    {
        _invoiceDetailRepository = invoiceDetailRepository;
        _mapper = mapper;
    }

    public void Create(InvoiceDetailInputDTO invoiceDetailInputDTO)
    {
        var invoiceDetail = _mapper.Map<InvoiceDetail>(invoiceDetailInputDTO);
        _invoiceDetailRepository.Create(invoiceDetail);
    }

    public void Delete(int invoiceDetailId)
    {
        var invoiceDetail = _invoiceDetailRepository.GetById(invoiceDetailId);
        if (invoiceDetail == null)
        {
            throw new KeyNotFoundException($"Invoice detail with id {invoiceDetailId} not found");
        }

        _invoiceDetailRepository.Delete(invoiceDetail);
    }

    public IEnumerable<InvoiceDetailDTO> GetAll()
    {
        var invoiceDetails = _invoiceDetailRepository.GetAll();
        return _mapper.Map<IEnumerable<InvoiceDetailDTO>>(invoiceDetails);
    }

    public InvoiceDetailDTO GetById(int invoiceDetailId)
    {
        var invoiceDetail = _invoiceDetailRepository.GetById(invoiceDetailId);
        if (invoiceDetail == null)
        {
            throw new KeyNotFoundException($"Invoice detail with id {invoiceDetailId} not found");
        }

        return _mapper.Map<InvoiceDetailDTO>(invoiceDetail);
    }

    public void Update(int invoiceDetailId, InvoiceDetailInputDTO invoiceDetailInputDTO)
    {
        var invoiceDetail = _invoiceDetailRepository.GetById(invoiceDetailId);
        if (invoiceDetail == null)
        {
            throw new KeyNotFoundException($"Invoice detail with id {invoiceDetailId} not found");
        }

        _mapper.Map(invoiceDetailInputDTO, invoiceDetail);
        _invoiceDetailRepository.Update(invoiceDetail);
    }
}