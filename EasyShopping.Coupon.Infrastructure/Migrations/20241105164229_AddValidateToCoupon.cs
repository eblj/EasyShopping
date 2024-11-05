using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyShopping.Coupon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddValidateToCoupon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Validate",
                table: "Coupons",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Validate",
                table: "Coupons");
        }
    }
}
