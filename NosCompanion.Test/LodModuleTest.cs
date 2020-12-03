using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NosCompanion.Test
{
    public class LodModuleTest
    {
        [Theory]
        [InlineData(0, 0, LodState.OnGoing)]
        [InlineData(1, 1, LodState.Closed)]
        [InlineData(2, 2, LodState.Open)]
        public void Lod_state_check(int hour, int minute, LodState correctState)
        {
            var dt = new DateTime(2020, 12, 03, hour, minute, 0, DateTimeKind.Local);

            LodModule.GetLodState(dt).ShouldBe(correctState);
        }

        [Theory]
        [InlineData(20, 1)]
        [InlineData(23, 2)]
        [InlineData(02, 3)]
        [InlineData(05, 4)]
        [InlineData(08, 5)]
        [InlineData(11, 2)]
        [InlineData(14, 3)]
        [InlineData(17, 4)]
        public void Lod_chanel_check(int hour, int correctChannel)
        {
            var dt = new DateTime(2020, 12, 03, hour, hour, 0, DateTimeKind.Local);
            LodModule.GetLodChanel(dt).ShouldBe(correctChannel);
        }
    }
}
