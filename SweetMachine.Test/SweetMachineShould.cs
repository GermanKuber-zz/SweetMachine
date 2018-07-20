using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Xunit;

namespace SweetMachine.Test
{
    public class SweetMachineShould
    {
        private SweetMachine _sut;
        private readonly List<ICandy> _mockListOfCandies = new List<ICandy> { new Mock<ICandy>().Object };

        public SweetMachineShould()
        {
            _sut = new SweetMachine(_mockListOfCandies);
            _sut.InsertMoney(5);  
        }

        [Fact]
        public void ReceiveMoney()
        {
            _sut.QuantityOfMOney.Should().Be(5);
        }

        [Fact]
        public void Return_Money()
        {
            _sut.ReturnMoney().Should().Be(5);
            _sut.QuantityOfMOney.Should().Be(0);
        }

        [Fact]
        public void Simulate_Error()
        {
            _sut.SimulateError();
            _sut.IsWorking().Should().Be(false);
        }
        [Fact]
        public void Is_Working()
        {
            _sut.IsWorking().Should().Be(true);
        }

        [Fact]
        public void Doest_Not_Accept_Money_If_Is_Not_Working()
        {
            _sut.SimulateError();
            Action act = () => _sut.InsertMoney(5);
            act.Should().Throw<IsNotWorkingException>();
        }

        [Fact]
        public void Return_Candy()
        {
            var mockCandy = new Mock<ICandy>();
            mockCandy.Setup(x => x.Price).Returns(-2);
            _sut = new SweetMachine(new List<ICandy> { mockCandy.Object });
            _sut.GiveMeCandy().Price.Should().Be(-2);
        }
        [Fact]
        public void Return_Nothing_If_Machine_Does_Not_Have_More_Candies()
        {
            _sut.GiveMeCandy().Price.Should().Be(0);
        }

        [Theory]
        [InlineData(1.5, 0.4)]
        [InlineData(2.35, 1.4)]
        public void Return_Multiple_Candy(decimal firstPrice, decimal secondPrice)
        {
            var mockCandy = new Mock<ICandy>();
            mockCandy.Setup(x => x.Price).Returns(firstPrice);
            var mockCandy2 = new Mock<ICandy>();
            mockCandy2.Setup(x => x.Price).Returns(secondPrice);

            _sut = new SweetMachine(new List<ICandy> { mockCandy.Object, mockCandy2.Object });

            _sut.GiveMeCandy(2).Price.Should().Be(firstPrice + secondPrice);
        }
    }
}
