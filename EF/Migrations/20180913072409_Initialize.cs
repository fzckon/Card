using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EF.Card.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BankAbbr = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    EnBankAbbr = table.Column<string>(nullable: true),
                    EnBankName = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BillAmount = table.Column<decimal>(nullable: false),
                    BillStatus = table.Column<int>(nullable: false),
                    BillingDate = table.Column<DateTime>(nullable: false),
                    CardId = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    RepayAmount = table.Column<decimal>(nullable: false),
                    RepayDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardInfos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BankId = table.Column<string>(nullable: true),
                    BillingDay = table.Column<int>(nullable: true),
                    CardAmount = table.Column<decimal>(nullable: true),
                    CardCurrency = table.Column<int>(nullable: true),
                    CardCvv = table.Column<string>(nullable: true),
                    CardCvv2 = table.Column<string>(nullable: true),
                    CardLevel = table.Column<int>(nullable: false),
                    CardName = table.Column<string>(nullable: true),
                    CardNo = table.Column<string>(nullable: true),
                    CardOrg = table.Column<int>(nullable: false),
                    CardStatus = table.Column<int>(nullable: false),
                    CardTempAmount = table.Column<decimal>(nullable: true),
                    CardType = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    HandleDate = table.Column<DateTime>(nullable: false),
                    OpenBankName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    QPassword = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    RepayDay = table.Column<int>(nullable: true),
                    ReservedTel = table.Column<string>(nullable: true),
                    ValidDate = table.Column<DateTime>(nullable: false),
                    ValidThru = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardShares",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CardId = table.Column<string>(nullable: true),
                    CardShareStatus = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardShares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    FriendId = table.Column<string>(nullable: true),
                    FriendStatus = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPwds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPwds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "CardInfos");

            migrationBuilder.DropTable(
                name: "CardShares");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "UserPwds");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
