namespace DemoMvcProject.Web.Models.CartViewModels
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            Items = new List<CartItemViewModel>();
        }
        public int Id { get; set; }
        public List<CartItemViewModel> Items { get; set; }
        public decimal Total { get; set; }

    }
}
