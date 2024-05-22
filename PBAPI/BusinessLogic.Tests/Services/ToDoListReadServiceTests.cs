using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Services;
using DB.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests.Services
{
    [TestFixture]
    internal class ToDoListReadServiceTests
    {
        private Mock<IToDoListItemRepository> _toDoListRepositoryMock;

        private ToDoListReadService _service;

        [SetUp]
        public void SetUp()
        {
            _toDoListRepositoryMock = new();

            _service = new(_toDoListRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllActiveAsync_should_return_NotFound_when_no_record_is_found()
        {
            // arrange
            List<ToDoListItem> returnedList = null!;
            _toDoListRepositoryMock
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(returnedList!);

            // act
            var result = await _service.GetAllActiveAsync();

            // assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Data, Is.Null);
        }
    }
}
