using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class changetablesnames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "tblUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "tblUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "tblUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "tblUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "tblUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "tblRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "tblRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "tblUserRoles",
                newName: "IX_tblUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "tblUserLogins",
                newName: "IX_tblUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "tblUserClaims",
                newName: "IX_tblUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "tblRoleClaims",
                newName: "IX_tblRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUserTokens",
                table: "tblUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUsers",
                table: "tblUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUserRoles",
                table: "tblUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUserLogins",
                table: "tblUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUserClaims",
                table: "tblUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblRoles",
                table: "tblRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblRoleClaims",
                table: "tblRoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblRoleClaims_tblRoles_RoleId",
                table: "tblRoleClaims",
                column: "RoleId",
                principalTable: "tblRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserClaims_tblUsers_UserId",
                table: "tblUserClaims",
                column: "UserId",
                principalTable: "tblUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserLogins_tblUsers_UserId",
                table: "tblUserLogins",
                column: "UserId",
                principalTable: "tblUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserRoles_tblRoles_RoleId",
                table: "tblUserRoles",
                column: "RoleId",
                principalTable: "tblRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserRoles_tblUsers_UserId",
                table: "tblUserRoles",
                column: "UserId",
                principalTable: "tblUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserTokens_tblUsers_UserId",
                table: "tblUserTokens",
                column: "UserId",
                principalTable: "tblUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblRoleClaims_tblRoles_RoleId",
                table: "tblRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserClaims_tblUsers_UserId",
                table: "tblUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserLogins_tblUsers_UserId",
                table: "tblUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserRoles_tblRoles_RoleId",
                table: "tblUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserRoles_tblUsers_UserId",
                table: "tblUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserTokens_tblUsers_UserId",
                table: "tblUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUserTokens",
                table: "tblUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUsers",
                table: "tblUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUserRoles",
                table: "tblUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUserLogins",
                table: "tblUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUserClaims",
                table: "tblUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblRoles",
                table: "tblRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblRoleClaims",
                table: "tblRoleClaims");

            migrationBuilder.RenameTable(
                name: "tblUserTokens",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "tblUsers",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "tblUserRoles",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "tblUserLogins",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "tblUserClaims",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "tblRoles",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "tblRoleClaims",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_tblUserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_tblUserLogins_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tblUserClaims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tblRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
