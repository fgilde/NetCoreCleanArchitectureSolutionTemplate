using System.IO;
using System.Text;
using $ext_safeprojectname$.Application.Contracts;
using $ext_safeprojectname$.Resources.Serializer;
using Xunit;

namespace $safeprojectname$.Resources
{
    public class JsonSerializerTest
    {
        [Fact]
        public void TestSerialize()
        {
            const string expected = @"{""Text"":""fooBar"",""Number"":42}";

            IJsonSerializer serializer = new JsonSerializer();
            Assert.Equal(expected, serializer.Serialize(new Obj()));
        }

        [Fact]
        public void TestDeserialize()
        {
            const string json = @"{""Text"":""miauWauWau"",""Number"":13}";

            IJsonSerializer serializer = new JsonSerializer();
            var actual = serializer.Deserialize<Obj>(json);

            Assert.NotNull(actual);
            Assert.Equal("miauWauWau", actual.Text);
            Assert.Equal(13, actual.Number);
        }

        private class Obj
        {
            public string Text { get; set; } = "fooBar";
            public int Number { get; set; } = 42;
            [Suppress] public Stream NotSerializable { get; set; } = new MemoryStream(Encoding.UTF8.GetBytes(nameof(Obj)));
        }
    }
}
