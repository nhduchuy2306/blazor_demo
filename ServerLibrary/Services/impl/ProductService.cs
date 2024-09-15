using AutoMapper;
using ServerLibrary.Dtos;
using ServerLibrary.Models;
using ServerLibrary.Repositories;

namespace ServerLibrary.Services.impl;

public class ProductService : IProductService
{
    private readonly ProductRepository _productRepository;
    private readonly WarehouseProductRepository _warehouseProductRepository;
    private readonly IMapper _mapper;

    public ProductService(ProductRepository productRepository, WarehouseProductRepository warehouseProductRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _warehouseProductRepository = warehouseProductRepository;
        _mapper = mapper;
    }

    public void Create(ProductInputDTO productInputDTO)
    {
        var product = _mapper.Map<Product>(productInputDTO);
        var newProduct = _productRepository.Create(product);
        if(newProduct != null)
        {
            var warehouseProduct = _warehouseProductRepository.GetById(productInputDTO.WarehouseId, newProduct.ProductId);

            if (warehouseProduct != null)
            {
                warehouseProduct.StockQuantity += productInputDTO.StockQuantity;
                _warehouseProductRepository.Update(warehouseProduct);
            }
        }
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

    public void Update(int productId, ProductUpdateDTO productUpdateDTO)
    {
        var existingProduct = _productRepository.GetById(productId);
        if (existingProduct == null)
        {
            throw new Exception("Product not found");
        }

        existingProduct.ProductCode = productUpdateDTO.ProductCode;
        existingProduct.ProductName = productUpdateDTO.ProductName;
        existingProduct.UnitPrice = productUpdateDTO.UnitPrice;
        _productRepository.Update(existingProduct);

        var warehouseProducts = productUpdateDTO.Warehouses;

        foreach (var warehouseProduct in warehouseProducts)
        {
            var existingWarehouseProduct = _warehouseProductRepository.GetById(warehouseProduct.WarehouseId, warehouseProduct.ProductId);
            if (existingWarehouseProduct == null)
            {
                throw new Exception("WarehouseProduct not found");
            }
            existingWarehouseProduct.StockQuantity = warehouseProduct.StockQuantity;
            _warehouseProductRepository.Update(existingWarehouseProduct);
        }
    }
}
