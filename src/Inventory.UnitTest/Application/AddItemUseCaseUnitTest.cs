using Inventory.Application.item;
using Inventory.Domain.Aggregates.Items;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Inventory.UnitTest.Application
{
    public class AddItem_Should
    {
        private readonly AddItemUseCase sut;

        private readonly Mock<IItemRepository> repo;


        public AddItem_Should()
        {
            repo = new Mock<IItemRepository>();
            repo.Setup(r => r.UnitOfWork.SaveChangesAsync(default)).ReturnsAsync(1);

            sut = new AddItemUseCase(repo.Object);
        }

        [Fact]
        public async Task AddItem_Correctly()
        {
            string itemName = "test item";
            DateTime expiration = DateTime.Now.AddYears(1);

            await sut.Create(itemName, ItemType.Unknow, expiration);

            repo.Verify(x => x.Add(It.IsAny<Item>()), Times.Once);
        }
    }
}
