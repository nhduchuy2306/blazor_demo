using ServerLibrary.Dtos;

public interface IProductService
{
    ProductDTO GetByName(string productName);
    ProductDTO GetById(int productId);
    IEnumerable<ProductDTO> GetAll();
    void Delete(int productId);
    void Update(int productId, ProductInputDTO product);
    void Create(ProductInputDTO product);
}