using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AutoFixture.Xunit2;
using FluentAssertions;
using GlobalLogic.Test.Refactoring.Interfaces.OldCodeClasses;
using GlobalLogic.Test.Refactoring.Models;
using GlobalLogic.Test.Refactoring.OldCodeClasses;
using Moq;
using Tests.AAAPattern.xUnit.Attributes;
using Unity.Interception.Utilities;
using Xunit;

namespace GlobalLogic.Test.Refactoring.Tests
{
    public class OrderFilterTests
    {
        [Theory]
        [MoqInlineAutoData(10, 100, 30)]
        public void WriteOutFilterdAndPriceSortedOrders_Call_Execute(int size, int count, int countSkipped, [Frozen]Mock<IObservableCollectionFactory> observableCollectionFactory, Random random, OrderFilter sut)
        {
            //arrange
            observableCollectionFactory.Setup(service => service.GetCollection<Order>())
                .Returns(new ObservableCollection<Order>());
            var orders = new List<Order>(count);
            for (var i = 0; i < count; i++)
            {
                var element = new Order
                {
                    Price = random.Next(count) + random.Next(count) * 0.01,
                    Size = i < countSkipped ? random.Next(size) : size + 1
                };
                orders.Add(element);
            }

            var actual = new ObservableCollection<Order>();
            orders.Where(order => order.Size > size).OrderBy(o => o.Price).ForEach(actual.Add);

            //act
            var expected = sut.WriteOutFilterdAndPriceSortedOrders(orders, size);

            //assert
            observableCollectionFactory.Verify(service => service.GetCollection<Order>(), Times.Once);
            observableCollectionFactory.VerifyNoOtherCalls();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
