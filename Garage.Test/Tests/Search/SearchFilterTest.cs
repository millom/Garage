//using Garage.SearchFilter;
using Garage.Search;
using Garage.Types;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Test.Tests.Search
{
    public class SearchFilterTest
    {
        [Fact]
        public void GivenAllPropHasValues_WhenRestAll_ThenAllValuesNull()
        {
            // Arrange
            ISearchFilter filter = new SearchFilter
            {
                RegNumber = "ABC123",
                Color = ColorType.BLUE,
                Weels = 4,
                ExtraProp = 2
            };

            // Act
            filter.ResetAll();

            // Assert
            Assert.Null(filter.RegNumber);
            Assert.Null(filter.Color);
            Assert.Null(filter.Weels);
            Assert.Null(filter.ExtraProp);
        }

        [Fact]
        public void GivenExpectedValues_WhenCreateObject_ThenAllExpevtedValues()
        {
            // Arrange & Act
            var expectedRegNumber = "ABC123";
            var expectedColor = ColorType.BLUE;
            var expectedWeels = 4;
            var expectedExtraProp = 2;

            // Act
            ISearchFilter filter = new SearchFilter
            {
                RegNumber = expectedRegNumber,
                Color = expectedColor,
                Weels = expectedWeels,
                ExtraProp = expectedExtraProp
            };

            // Assert
            Assert.Equal(expectedRegNumber, filter.RegNumber);
            Assert.Equal(expectedColor, filter.Color);
            Assert.Equal(expectedWeels, filter.Weels);
            Assert.Equal(expectedExtraProp, filter.ExtraProp);
        }

        [Fact]
        public void GivenDefaultValues_WhenCreateDefaultObject_ThenAllValuesNull()
        {
            // Arrange & Act
            ISearchFilter filter = new SearchFilter();

            // Assert
            Assert.Null(filter.RegNumber);
            Assert.Null(filter.Color);
            Assert.Null(filter.Weels);
            Assert.Null(filter.ExtraProp);
        }
    }
}
