using BaltaStore.Domain.StoreContent.Entities;
using BaltaStore.Domain.StoreContent.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var customer = new Customer(
                new Name("George", "Bonespírito"),
                new Document("12312213"),
                new Email("torgge@gmail.com"),
                "1312312312");

//            var mouse = new Product("Mouse", "Mouse Óptico", "img.png", 12.50M, 12);
//            var teclado = new Product("Teclado", "Teclado Mecânico", "img.png", 46.54M, 122);
//            var monitor = new Product("Monitor", "Monitor VGA", "img.png", 12.50M, 1);
//            var oi = new OrderItem(monitor, 0);
            
            var order = new Order(customer);
//            order.AddItem(new OrderItem(mouse, 20));
//            order.AddItem(new OrderItem(teclado, 10));
//            order.AddItem(new OrderItem(monitor, 40));
            
            //Realizei o Pedido.
            order.Place();

            var valid = order.Valid;
            
            order.Pay();
            
            order.Ship();
            
            order.Cancel();
        }
    }
}