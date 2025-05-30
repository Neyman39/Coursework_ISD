using Moq;
using PROVERKA;
using PROVERKA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace TestInsurance
{
    [TestClass]
    public class Tests
    {
        private Mock<INDbContext> _mockDb;
        private FacadeDB _facade;

        [TestInitialize]
        public void Setup()
        {
            _mockDb = new Mock<INDbContext>();

            // ��������� ������� ��� �������� ���������
            FacadeDB.SetDbContextFunc(() => _mockDb.Object);

            // ������� ��������� FacadeDB
            _facade = new FacadeDB();
        }

        [TestMethod]
        public void CalculateCascoCost_ShouldApplyCorrectMultipliers()
        {
            // Arrange
            // ����������� mock ��� Fields
            var fields = new List<Field>
            {
                new Field { IdField = 1, Name = "���� ��������", Type = "number" },
                new Field { IdField = 2, Name = "�������� ���������", Type = "number" }
            };

            _mockDb.Setup(db => db.Fields).Returns(CreateMockDbSet(fields.AsQueryable()));

            // �������� ������
            var fieldValues = new Dictionary<int, string>
            {
                {1, "1"},   // ���� �������� (1 ���)
                {2, "210"}  // �������� ��������� (210 �.�.)
            };

            decimal baseCost = 20000m;
            decimal expectedCost = 20000m * 1.6m * 1.5m;

            // Act
            decimal actualCost = _facade.CalculateCascoCost(fieldValues, baseCost);

            // Assert
            Assert.AreEqual(expectedCost, actualCost, "������������ ������ ��������� �����");
        }

        [TestMethod]
        public void CalculateHealthCost_ShouldApplyCorrectMultipliers()
        {
            // Arrange
            // ����������� mock ��� Fields
            var fields = new List<Field>
            {
                new Field { IdField = 1, Name = "�������", Type = "number" },
                new Field { IdField = 2, Name = "������� ��������� ������������", Type = "number" }
            };

            _mockDb.Setup(db => db.Fields).Returns(CreateMockDbSet(fields.AsQueryable()));

            // �������� ������
            var fieldValues = new Dictionary<int, string>
            {
                {1, "65"},  // ������� (65 ���)
                {2, "3"}    // ������� ��������� (3 �������)
            };

            decimal baseCost = 10000m;
            decimal expectedCost = 10000m * 1.8m * 1.6m; // 65 ��� (1.8) + 3 ������� ��������� (1.6)

            // Act
            decimal actualCost = _facade.CalculateHealthCost(fieldValues, baseCost);

            // Assert
            Assert.AreEqual(expectedCost, actualCost, "������������ ������ ��������� ��������� ��������");
        }

        [TestMethod]
        public void CreateAgreement_ShouldReturnTrueAndSaveAgreement_WhenValidData()
        {
            // Arrange
            var mockAgreements = new Mock<DbSet<Agreement>>();
            _mockDb.Setup(db => db.Agreements).Returns(mockAgreements.Object);
            _mockDb.Setup(db => db.SaveChanges()).Returns(1); // ���������� �������� ����������

            decimal sumInsured = 50000m;
            int? idAgent = 1;
            int? idClient = 1;
            int? branchId = 1;
            int? insuranceId = 1;
            decimal? agentPremium = 5000m;

            // Act
            bool result = _facade.CreateAgreement(sumInsured, idAgent, idClient, branchId, insuranceId, agentPremium);

            // Assert
            Assert.IsTrue(result, "������� �� ��� ������");
            mockAgreements.Verify(db => db.Add(It.IsAny<Agreement>()), Times.Once());
            _mockDb.Verify(db => db.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void CreateAgreement_ShouldReturnFalse_WhenSaveFails()
        {
            // Arrange
            var mockAgreements = new Mock<DbSet<Agreement>>();
            _mockDb.Setup(db => db.Agreements).Returns(mockAgreements.Object);
            _mockDb.Setup(db => db.SaveChanges()).Throws(new Exception("Database error")); // ���������� ������

            // Act
            bool result = _facade.CreateAgreement(50000m, 1, 1, 1, 1, 5000m);

            // Assert
            Assert.IsFalse(result, "����� ������ ������� false ��� ������ ����������");
        }

        private DbSet<T> CreateMockDbSet<T>(IQueryable<T> data) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            return mockSet.Object;
        }

        [TestCleanup]
        public void Cleanup()
        {
            // ��������������� ������������ ������� ����� �����
            FacadeDB.ResetDbContextFunc();
        }
    }
}