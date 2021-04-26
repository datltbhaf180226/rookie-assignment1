using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1.Migrations
{
    public partial class newUpdateDataBaseName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRequest_User_UserId",
                table: "BorrowRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRequestDetail_Book_BookId",
                table: "BorrowRequestDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRequestDetail_BorrowRequest_BorrowRequestId",
                table: "BorrowRequestDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowRequestDetail",
                table: "BorrowRequestDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowRequest",
                table: "BorrowRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "BorrowRequestDetail",
                newName: "BorrowRequestDetails");

            migrationBuilder.RenameTable(
                name: "BorrowRequest",
                newName: "BorrowRequests");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowRequestDetail_BookId",
                table: "BorrowRequestDetails",
                newName: "IX_BorrowRequestDetails_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowRequest_UserId",
                table: "BorrowRequests",
                newName: "IX_BorrowRequests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_CategoryId",
                table: "Books",
                newName: "IX_Books_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowRequestDetails",
                table: "BorrowRequestDetails",
                columns: new[] { "BorrowRequestId", "BookId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowRequests",
                table: "BorrowRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRequestDetails_Books_BookId",
                table: "BorrowRequestDetails",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRequestDetails_BorrowRequests_BorrowRequestId",
                table: "BorrowRequestDetails",
                column: "BorrowRequestId",
                principalTable: "BorrowRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRequests_Users_UserId",
                table: "BorrowRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRequestDetails_Books_BookId",
                table: "BorrowRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRequestDetails_BorrowRequests_BorrowRequestId",
                table: "BorrowRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRequests_Users_UserId",
                table: "BorrowRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowRequests",
                table: "BorrowRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowRequestDetails",
                table: "BorrowRequestDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "BorrowRequests",
                newName: "BorrowRequest");

            migrationBuilder.RenameTable(
                name: "BorrowRequestDetails",
                newName: "BorrowRequestDetail");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowRequests_UserId",
                table: "BorrowRequest",
                newName: "IX_BorrowRequest_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowRequestDetails_BookId",
                table: "BorrowRequestDetail",
                newName: "IX_BorrowRequestDetail_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_CategoryId",
                table: "Book",
                newName: "IX_Book_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowRequest",
                table: "BorrowRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowRequestDetail",
                table: "BorrowRequestDetail",
                columns: new[] { "BorrowRequestId", "BookId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRequest_User_UserId",
                table: "BorrowRequest",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRequestDetail_Book_BookId",
                table: "BorrowRequestDetail",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRequestDetail_BorrowRequest_BorrowRequestId",
                table: "BorrowRequestDetail",
                column: "BorrowRequestId",
                principalTable: "BorrowRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
