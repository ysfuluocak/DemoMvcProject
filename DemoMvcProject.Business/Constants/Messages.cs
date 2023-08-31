using DemoMvcProject.Core.Entities.Concrete;
using DemoMvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcProject.Business.Constants
{
    public static class Messages
    {
        public static string ProductNotFound = "Ürün bulunamadı!";
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductDeleted = "Ürün silindi";
        public static string ProductListed = "Ürünler listelendi";
        public static string ProductShown = "Ürün gösterildi";
        public static string ProductUpdated = "Ürün güncellendi";
        public static string ProductStockUpdated = "Ürün stok güncellendi";
        public static string ProductStockNotUpdated = "Ürün stok güncellenemedi";
        public static string CategoryAdded ="Kategori eklendi";
        public static string CategoryDeleted ="Kategori silindi";
        public static string CategoryUpdated ="Ketagori güncellendi";
        public static string CategoryListed ="Kategoriler listelendi";
        public static string CategoryShown="Kategori gösterildi";
        public static string CartItemsListed = "Sepet ürünleri listelendi";
        public static string CartItemShown = "Sepet ürünü gösterildi";
        public static string CartItemUpdated="Sepet ürünü güncellendi";
        public static string CartAdded="Sepet oluşturuldu";
        public static string OutOfStock = "Stok yeterli değil";
        public static string CartUpdated ="Sepet güncellendi";
        public static string OrderCompleted = "Siparis tamalandı";
        public static string CartShown ="Sepet gösterildi";
        public static string CartsListed = "Sepetler listelendi";
        public static string ActiveCartsListed ="Aktif sepetler listelendi";
        public static string CartItemDeletedForCart ="Ürün sepetten silindi";
        public static string CartDeleted = "Sepet silindi";
        public static string CartItemAddedForCart = "Ürün sepete eklendi";
        public static string PublishCategoryListed = "Yayınlanan kategori listelendi";
        public static string PublishCategoryShown = "Yayınlanan kategori gösterildi";
        public static string ProductPhotoAdded = "Ürün fotoğrafı eklendi";
        public static string ProductPhotoDeleted = "Ürün fotoğrafı silindi";
        public static string ProductPhotoShown = "Ürün fotoğrafı gösterildi";
        public static string PublishProductPhotoShown = "Yayınlanan ürün fotoğrafı gösterildi";
        public static string ProductPhotosListed = "Ürün fotoğrafları listelendi";
        public static string PublishProductPhotosListed = "Yayınlanan ürün fotoğrafları listelendi";
        public static string ProductPhotoUpdated = "Ürün fotoğrafı güncellendi";
        public static string UserAlreadyExist ="Kullanıcı mevcut";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserNotExist ="Kayıtlı kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string LoginSuccessful ="Giriş başarılı";

        public static string UserDeleted { get; internal set; }
        public static string UserListed { get; internal set; }
        public static string UserShown { get; internal set; }
        public static string UserUpdated { get; internal set; }
        public static string CustomerAdded { get; internal set; }
        public static string CustomerDeleted { get; internal set; }
        public static string CustomersListed { get; internal set; }
        public static string CustomerShown { get; internal set; }
        public static string CustomerUpdated { get; internal set; }
        public static string ClaimAdded { get; internal set; }
        public static string ClaimDeleted { get; internal set; }
        public static string ClaimUpdated { get; internal set; }
        public static string ClaimAddedToUser { get; internal set; }
        public static string ClaimDeletedToUser { get; internal set; }
        public static string ClaimUpdatedToUser { get; internal set; }
        public static IEnumerable<OperationClaim> ClaimNotFountForUser { get; internal set; }
        public static string ClaimsListed { get; internal set; }
        public static Customer CustomerNotFound { get; internal set; }
    }
}
