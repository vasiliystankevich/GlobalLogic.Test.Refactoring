using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoFixture.Xunit2;
using GlobalLogic.Test.Refactoring.Interfaces.OldCodeClasses;
using GlobalLogic.Test.Refactoring.Models;
using Moq;
using Tests.AAAPattern.xUnit.Attributes;
using Xunit;

namespace GlobalLogic.Test.Refactoring.Tests
{
    public class StartupTests
    {
        [Theory]
        [MoqInlineAutoData]
        public void Execute_Call_Execute(string[] args, List<Order> orders, ObservableCollection<Order> largeResult,
            ObservableCollection<Order> smallResult, [Frozen] Settings settings, [Frozen] Mock<IOrderStore> orderStore,
            [Frozen] Mock<IOrderFilter> orderFilter, [Frozen] Mock<IOrderWriter> orderWriter, Startup sut)
        {
            //arrange
            orderStore.Setup(service => service.GetOrders()).Returns(orders);
            orderFilter.Setup(service =>
                    service.WriteOutFilterdAndPriceSortedOrders(orders, settings.SizesOrderLists.Large))
                .Returns(largeResult);
            orderFilter.Setup(service =>
                    service.WriteOutFilterdAndPriceSortedOrders(orders, settings.SizesOrderLists.Small))
                .Returns(smallResult);

            //act
            sut.Execute(args);

            //assert
            orderStore.Verify(service => service.GetOrders(), Times.Once);
            orderFilter.Verify(
                service => service.WriteOutFilterdAndPriceSortedOrders(orders, settings.SizesOrderLists.Large),
                Times.Once);
            orderFilter.Verify(
                service => service.WriteOutFilterdAndPriceSortedOrders(orders, settings.SizesOrderLists.Small),
                Times.Once);
            orderWriter.Verify(service => service.WriteOrders(largeResult), Times.Once);
            orderWriter.Verify(service => service.WriteOrders(smallResult), Times.Once);
            
            orderStore.VerifyNoOtherCalls();
            orderFilter.VerifyNoOtherCalls();
            orderWriter.VerifyNoOtherCalls();
        }
    }
}
