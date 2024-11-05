using NguyenMinhHiep220900100project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NguyenMinhHiep220900100project2.Controllers
{
    public class ShoppingCartController : Controller
    {
        // Giỏ hàng tĩnh để lưu trữ
        private static ShoppingCart cart = new ShoppingCart();

        // Xem giỏ hàng
        public ActionResult Index()
        {
            return View(cart.GetItems());
        }

        // Thêm sản phẩm vào giỏ hàng
        public ActionResult AddToCart(int maSanPham, string tenSanPham, decimal gia, int soLuong)
        {
            cart.AddItem(maSanPham, tenSanPham, gia, soLuong);
            return RedirectToAction("Index");
        }

        // Cập nhật số lượng sản phẩm trong giỏ hàng
        [HttpPost]
        public ActionResult UpdateQuantity(int maSanPham, int soLuong)
        {
            cart.UpdateItemQuantity(maSanPham, soLuong);
            return RedirectToAction("Index");
        }

        // Xóa sản phẩm khỏi giỏ hàng
        public ActionResult RemoveFromCart(int maSanPham)
        {
            cart.RemoveItem(maSanPham);
            return RedirectToAction("Index");
        }

        // Thanh toán (chỉ là mẫu, chưa xử lý thực tế)
        public ActionResult Checkout()
        {
            // Xử lý thanh toán ở đây
            cart.Clear();  // Xóa giỏ hàng sau khi thanh toán
            return View();
        }
    }
}
