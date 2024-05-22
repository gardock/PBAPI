using BusinessLogic.Enums;
using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using DB.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests.Services
{
    internal class ToDoListServiceTests
    {
        private Mock<IToDoListItemRepository> _toDoListRepositoryMock;
        private Mock<IToDoListReadService> _toDoListReadServiceMock;
        private Mock<IToDoListOrderingService> _toDoListOrderingServiceMock;

        private ToDoListService _service;

        [SetUp]
        public void SetUp()
        {
            _toDoListRepositoryMock = new();
            _toDoListReadServiceMock = new();
            _toDoListOrderingServiceMock = new();

            _service = new(_toDoListRepositoryMock.Object, _toDoListReadServiceMock.Object, _toDoListOrderingServiceMock.Object);
        }

        [Test]
        public async Task DeleteToDoListItemAsync_should_return_Success_if_no_record_found()
        {
            // arrange
            var recordId = 123;
            _toDoListRepositoryMock
                .Setup(x => x.GetOneAsync(recordId))
                .ReturnsAsync((ToDoListItem?)null);

            // act
            var result = await _service.DeleteToDoListItemAsync(recordId);

            // assert
            Assert.That(result.IsSuccess, Is.True);
        }

        [Test]
        public async Task DeleteToDoListItemAsync_should_return_ItemIsInProgress_when_record_is_in_InProgress_status()
        {
            // arrange
            var recordId = 123;
            var item = ToDoListItem.CreateNew("test", "123");
            item.Status = DB.Enums.ToDoListItemStatus.InProgress;
            item.Id = recordId;
            _toDoListRepositoryMock
                .Setup(x => x.GetOneAsync(recordId))
                .ReturnsAsync(item);

            // act
            var result = await _service.DeleteToDoListItemAsync(recordId);

            // assert
            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.ServiceResultStatus, Is.EqualTo(ServiceResultStatus.ItemIsInProgress));
            });
        }

        [Test]
        public async Task DeleteToDoListItemAsync_should_return_success_when_item_exists_and_not_in_progress()
        {
            // arrange
            var recordId = 123;
            var item = ToDoListItem.CreateNew("test", "123");
            item.Id = recordId;
            _toDoListRepositoryMock
                .Setup(x => x.GetOneAsync(recordId))
                .ReturnsAsync(item);

            _toDoListOrderingServiceMock
                .Setup(x => x.UpdateListItemOrder(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(new Result.ServiceResult(ServiceResultStatus.Success));

            // act
            var result = await _service.DeleteToDoListItemAsync(recordId);

            // assert
            Assert.That(result.IsSuccess, Is.True);
        }
    }
}
