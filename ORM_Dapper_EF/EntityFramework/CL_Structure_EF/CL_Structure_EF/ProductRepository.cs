namespace CL_Structure_EF
{
    public class ProductRepository
    {
        private ApplicationContext _context;

        public ProductRepository()
        {
            _context = new ApplicationContext();
        }
        public void Create(ProductModel item)
        {
            _context.Product.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Product.Remove(new ProductModel() { Product_Id = id });
            _context.SaveChanges();
        }

        public ProductModel Get(int id)
        {
            return _context.Product.Where(x => x.Product_Id == id).FirstOrDefault();
        }

        public List<ProductModel> GetItems()
        {
            return _context.Product.ToList();
        }

        public void Update(ProductModel item)
        {
            _context.Product.Update(item);
            _context.SaveChanges();
        }
    }
}
