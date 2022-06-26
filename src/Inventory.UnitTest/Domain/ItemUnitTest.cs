using FluentAssertions;
using Inventory.Domain.Aggregates.Items;
using System;
using Xunit;

namespace Inventory.UnitTest.Domain
{
    public class Item_Should
    {

        [Fact]
        public void Instantiate_Succesfull()
        {
            string itemName = "test item";
            DateTime expiration = DateTime.Now.AddYears(1);
            Item item = new(itemName, expiration, ItemType.Unknow);

            item.Name.Should().Be(itemName);
            item.ExpirationDate.Should().Be(expiration);
            item.Type.Should().Be(ItemType.Unknow);

        }

        [Fact]
        public void ThrowArgumentException_WhenNameIsNullOrEmpty()
        {
            DateTime expiration = DateTime.Now.AddYears(1);

            Action CreateWithParam(string x)
            {
                return () =>
                {
                    Item item = new(x, expiration, ItemType.Unknow);
                };
            }

            CreateWithParam(null).Should().Throw<ArgumentException>();
            CreateWithParam("").Should().Throw<ArgumentException>();
        }
    }
}
