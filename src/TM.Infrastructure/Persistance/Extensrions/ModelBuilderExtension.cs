using Microsoft.EntityFrameworkCore;
using TM.Application.Common.Helpers;
using TM.Domain.Entities;
using TM.Domain.Enums;

namespace TM.Infrastructure.Persistance.Extensrions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var pairs = new List<Pair>
            {
                new() { ID = Guid.NewGuid().ToString(), Name = "BTCUSDT", Description = "BTCUSDT pair" },
                new() { ID = Guid.NewGuid().ToString(), Name = "ETHUSDT", Description = "ETHUSDT pair" },
                new() { ID = Guid.NewGuid().ToString(), Name = "SOLUSDT", Description = "SOLUSDT pair" }
            };
            modelBuilder.Entity<Pair>().HasMany(x => x.Trades).WithOne(x => x.Pair);
            modelBuilder.Entity<Pair>().HasData(pairs);


            var factors = new List<Factor>
            {
                new() { ID = Guid.NewGuid().ToString(), UserID = Guid.NewGuid().ToString(), Name = "OB", Description = "Order block", Priority = 1 },
                new() { ID = Guid.NewGuid().ToString(), UserID = Guid.NewGuid().ToString(), Name = "BOS", Description = "Break of structure", Priority = 2},
                new() { ID = Guid.NewGuid().ToString(), UserID = Guid.NewGuid().ToString(), Name = "FVG", Description = "Fair value gap", Priority = 2}
            };
            modelBuilder.Entity<Factor>().HasMany(x => x.Setups).WithMany(x => x.Factors);
            modelBuilder.Entity<Factor>().HasData(factors);


            var setups = new List<Setup>
            {
                new() { ID = Guid.NewGuid().ToString(), UserID = Guid.NewGuid().ToString(), Name = "Morning", Description = "test 1"},
                new() { ID = Guid.NewGuid().ToString(), UserID = Guid.NewGuid().ToString(), Name = "Afternoon", Description = "test 2"},
                new() { ID = Guid.NewGuid().ToString(), UserID = Guid.NewGuid().ToString(), Name = "Evening", Description = "test 3"}
            };
            modelBuilder.Entity<Setup>().HasMany(x => x.Factors).WithMany(x => x.Setups);
            modelBuilder.Entity<Setup>().HasData(setups);


            modelBuilder.Entity<Setup>()
                .HasMany(p => p.Factors)
                .WithMany(t => t.Setups)
                .UsingEntity<Dictionary<string, object>>(
                    "FactorSetup",
                    r => r.HasOne<Factor>().WithMany().HasForeignKey("FactorId"),
                    l => l.HasOne<Setup>().WithMany().HasForeignKey("SetupId"),
                    je =>
                    {
                        je.HasKey("SetupId", "FactorId");
                        je.HasData(
                            new
                            {
                                SetupId = setups[0].ID,
                                FactorId = factors[0].ID
                            },
                            new
                            {
                                SetupId = setups[0].ID,
                                FactorId = factors[1].ID
                            },
                            new
                            {
                                SetupId = setups[1].ID,
                                FactorId = factors[1].ID
                            },
                            new
                            {
                                SetupId = setups[1].ID,
                                FactorId = factors[2].ID
                            },
                            new
                            {
                                SetupId = setups[2].ID,
                                FactorId = factors[0].ID
                            },
                            new
                            {
                                SetupId = setups[2].ID,
                                FactorId = factors[2].ID
                            },
                            new
                            {
                                SetupId = setups[2].ID,
                                FactorId = factors[1].ID
                            }
                            );
                    });


            var trades = new List<Trade>
            {
                new()
                {
                    ID = Guid.NewGuid().ToString(),
                    PairID = pairs[0].ID,
                    SetupID = setups[0].ID,
                    UserID = Guid.NewGuid().ToString(),
                    Date = DateTime.Now,

                    DirectionType = DirectionType.Trend,
                    PositionType = PositionType.Long,

                    InitialDeposit = 500,

                    PriceEntry = 60000,
                    PriceStop = 59900,
                    PriceTake = 60500,
                    DepositRisk = 2,

                    Rating = 4,
                    ResultType = ResultType.Take
                },
                new()
                {
                    ID = Guid.NewGuid().ToString(),
                    PairID = pairs[1].ID,
                    SetupID = setups[2].ID,
                    UserID = Guid.NewGuid().ToString(),
                    Date = DateTime.Now,

                    DirectionType = DirectionType.Countertrand,
                    PositionType = PositionType.Short,

                    InitialDeposit = 500,

                    PriceEntry = 3200,
                    PriceStop = 3225,
                    PriceTake = 3150,
                    DepositRisk = 2,

                    Rating = 3,
                    ResultType = ResultType.Stop
                }
            };

            trades.ForEach(x =>
            {
                x.RiskRewardRatio = CalculationHelper.GetRiskRewardRatio(x.PriceEntry, x.PriceStop, x.PriceTake);
                x.Profit = CalculationHelper.GetProfit(x.PriceEntry, x.PriceStop, x.PriceTake, x.DepositRisk, x.InitialDeposit);
            });
            modelBuilder.Entity<Trade>().HasOne(x => x.Pair).WithMany(x => x.Trades);
            modelBuilder.Entity<Trade>().HasOne(x => x.Setup).WithMany(x => x.Trades);
            modelBuilder.Entity<Trade>().HasData(trades);

        }
    }
}
