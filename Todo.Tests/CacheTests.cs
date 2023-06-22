using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Todo.Tests
{
    public class CacheTests
    {
        [Fact]
        public void Get_ExistingKey_ReturnsCachedValue()
        {
            // Arrange
            var cache = new Todo.Cache.Cache();
            var key = "myKey";
            var expectedValue = "myValue";
            cache.Set(key, expectedValue, TimeSpan.FromMinutes(10));

            // Act
            var actualValue = cache.Get<string>(key);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Get_NonExistingKey_ReturnsDefault()
        {
            // Arrange
            var cache = new Todo.Cache.Cache();
            var key = "nonExistingKey";

            // Act
            var actualValue = cache.Get<string>(key);

            // Assert
            Assert.Null(actualValue);
        }

        [Fact]
        public void Set_AddsItemToCache()
        {
            // Arrange
            var cache = new Todo.Cache.Cache();
            var key = "myKey";
            var value = "myValue";
            var expiration = TimeSpan.FromMinutes(10);

            // Act
            cache.Set(key, value, expiration);
            var cachedValue = cache.Get<string>(key);

            // Assert
            Assert.Equal(value, cachedValue);
        }

        [Fact]
        public void Remove_RemovesItemFromCache()
        {
            // Arrange
            var cache = new Todo.Cache.Cache();
            var key = "myKey";
            var value = "myValue";
            cache.Set(key, value, TimeSpan.FromMinutes(10));

            // Act
            cache.Remove(key);
            var cachedValue = cache.Get<string>(key);

            // Assert
            Assert.Null(cachedValue);
        }
    }
}
