using AutoMapper;
using ServerLibrary.Dtos;
using ServerLibrary.Models;
using ServerLibrary.Repositories;

namespace ServerLibrary.Services.impl;

public class ProductService : IProductService
{
    private readonly ProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(ProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public void Create(ProductInputDTO product)
    {
        var productEntity = _mapper.Map<Product>(product);
        _productRepository.Create(productEntity);
    }

    public void Delete(int productId)
    {
        var product = _productRepository.GetById(productId);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        _productRepository.Delete(product);
    }

    public ProductDTO GetById(int productId)
    {
        var productEntity = _productRepository.GetById(productId);
        if (productEntity == null)
        {
            throw new Exception("Product not found");
        }
        return _mapper.Map<ProductDTO>(productEntity);
    }

    public ProductDTO GetByName(string productName)
    {
        var productEntity = _productRepository.GetByName(productName);
        if (productEntity == null)
        {
            throw new Exception("Product not found");
        }
        return _mapper.Map<ProductDTO>(productEntity);
    }

    public IEnumerable<ProductDTO> GetAll()
    {
        var productEntities = _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductDTO>>(productEntities);
    }

    public void Update(int productId, ProductInputDTO product)
    {
        var existingProduct = _productRepository.GetById(productId);
        if (existingProduct == null)
        {
            throw new Exception("Product not found");
        }
        var productEntity = _mapper.Map<Product>(product);
        productEntity.ProductId = productId;
        _productRepository.Update(productEntity);
    }
}
