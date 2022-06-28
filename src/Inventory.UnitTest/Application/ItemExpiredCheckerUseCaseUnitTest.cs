using EventBus;
using EventBus.Contracts;
using Inventory.Application.item;
using Inventory.Domain.Aggregates.Items;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Inventory.UnitTest.Application
{
    public class ItemExpiredChecker_Should
    {
        private readonly ItemExpiredCheckerUseCase sut;

        private readonly Mock<IItemRepository> repo;
        private readonly Mock<ILogger<ItemExpiredCheckerUseCase>> logger;
        private readonly Mock<IEventBus> eventBus;


        public ItemExpiredChecker_Should()
        {
            repo = new Mock<IItemRepository>();
            repo.Setup(r => r.UnitOfWork.SaveChangesAsync(default)).ReturnsAsync(1);

            logger = new Mock<ILogger<ItemExpiredCheckerUseCase>>();
            eventBus = new Mock<IEventBus>();

            sut = new ItemExpiredCheckerUseCase(logger.Object, repo.Object, eventBus.Object);
        }

        [Fact]
        public void PublishEvent_Correctly()
        {
            var itemList = new List<Item>() {
                new("expired", DateTime.Today.AddDays(-1), ItemType.Unknow)
            };

            repo
                .Setup(r => r.FindExpired())
                .Returns(itemList);

            sut.Check();

            eventBus.Verify(x => x.Publish(It.IsAny<IntegrationEvent>()), Times.Once);
        }
    }
}
