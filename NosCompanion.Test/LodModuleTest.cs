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
        [InlineData(0, 1, LodState.Closed)]
        [InlineData(1, 2, LodState.Open)]
        [InlineData(2, 0, LodState.OnGoing)]
        public void Lod_state_check(int hour, int minute, LodState correctState)
        {
            var dt = new DateTime(2000, 1, 1, hour, minute, 0);

            LodModule.GetLodState(dt).ShouldBe(correctState);
        }

        [Theory]
        [InlineData( 2, 1, 2)]
        [InlineData( 5, 1, 3)]
        [InlineData( 8, 1, 4)]
        [InlineData(11, 1, 5)]
        [InlineData(14, 1, 2)]
        [InlineData(17, 1, 3)]
        [InlineData(20, 1, 4)]
        [InlineData(23, 1, 1)]
        public void Lod_chanel_check(int hour, int minute, int correctChannel)
        {
            var dt = new DateTime(2000, 1, 1, hour, minute, 0);
            LodModule.GetLodChanel(dt).ShouldBe(correctChannel);
        }
    }
}
