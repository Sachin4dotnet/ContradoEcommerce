using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace Ecomm.DataModel.Migrations
{
    public partial class InitialDBScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql(File.ReadAllText("Migrations/20211129042801_InitialDBScript.sql"));

            //migrationBuilder.CreateTable(
            //    name: "ClientInfos",
            //    columns: table => new
            //    {
            //        ClientId = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FirstName = table.Column<string>(nullable: true),
            //        LastName = table.Column<string>(nullable: true),
            //        CompanyName = table.Column<string>(nullable: true),
            //        PhoneNumber = table.Column<string>(nullable: true),
            //        Email = table.Column<string>(nullable: true),
            //        WebSiteAddress = table.Column<string>(nullable: true),
            //        CommunicationAddress = table.Column<string>(nullable: true),
            //        City = table.Column<string>(nullable: true),
            //        State = table.Column<string>(nullable: true),
            //        ZipCode = table.Column<string>(nullable: true),
            //        Country = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ClientInfos", x => x.ClientId);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ClientInfos");
        }
    }
}
