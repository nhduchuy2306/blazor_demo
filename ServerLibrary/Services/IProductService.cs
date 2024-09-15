using ServerLibrary.Dtos;

namespace ServerLibrary.Services;

public interface IProductService
{
    ProductDTO GetByName(string productName);
    
    ProductDTO GetById(int productId);
    
    IEnumerable<ProductDTO> GetAll();
    
    void Delete(int productId);
    
    void Update(int productId, ProductUpdateDTO product);
    
    void Create(ProductInputDTO product);
}