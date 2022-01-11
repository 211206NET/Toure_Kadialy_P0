using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toure_Kadiay_P0.Models;
using Xunit;

namespace OrderSystemTest
{
    public class UnitTests
    {
        [Fact]
        public void IsValidStoreName()
        {
            Store store = new Store();
            store.Name = "";
            Assert.False(store.IsValidStoreName(), "The store name is not valid");
        }
        [Fact]
        public void IsValidProductPrice()
        {
            ProductOrder order = new ProductOrder();
            order.TotalPrice = 120;
            Assert.False(order.IsValidPrice(), "The product price is valid");
        }
        [Fact]
        public void IsValidProductOrderQty()
        {
            ProductOrder order = new ProductOrder();
            order.Quantity = 10;
            Assert.True(order.IsValidQuantity(), "The order product Qty is valid");
        }
        [Fact]
        public void IsValidProductID()
        {
            ProductOrder order = new ProductOrder();

            Assert.True(order.IsValidProductId("123"), "The product Id is valid");
        }
        [Fact]
        public void IsValidProductLocation()
        {
            Product product = new Product();
            product.Location = -1;
            Assert.False(product.IsValidProductLocation(), "The product location is not valid");
        }
        [Fact]
        public void IsValidProductName()
        {
            Product product = new Product();
            product.Name = "Product x";
            Assert.True(product.IsValidProductName(), "The product name is valid");

        }
        [Fact]
        public void IsValidOrderDate()
        {
            OrderMaster orderMaster = new OrderMaster();
            orderMaster.OrderDate = new DateTime().AddDays(1);
            Assert.True(orderMaster.IsValidOrderDate(), "The Order date is not valid");
        }
        [Fact]
        public void IsValidCustomerName()
        {
            OrderMaster orderMaster = new OrderMaster();
            orderMaster.CustomerName = "Customer x";
            Assert.True(orderMaster.IsValidCustomerName(), "The customer name is valid");
        }
        [Fact]
        public void IsValidPassword()
        {
            Customer customer = new Customer();
            customer.Password = "null";
            Assert.True(customer.IsValidPassword(), "The customer password is valid");
        }
        [Fact]
        public void IsValidCartProductQty()
        {
            Cart cart = new Cart();
            cart.Qty = 2;
            Assert.True(cart.IsValidProductQty(), "Quantity is valid");
        }
      

    }
}
