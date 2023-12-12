using ECommerceShopingCartASPNET8.Models;

namespace ECommerceShopingCartASPNET8.Services
{
    public interface ICartService
    {
        void AddItem(Product product, int quantity);
        void RemoveItem(string productId);
        void ClearCart();
        Cart GetCart();
    }
}
