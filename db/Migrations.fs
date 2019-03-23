module Migrations

open FluentMigrator

[<Migration(1L, "Adds user table")>]
type AddUserTable() =
    inherit Migration()

    override this.Up() =
        this.Create.Table("users")
            .WithColumn("id").AsInt64().PrimaryKey().Identity()
            .WithColumn("username").AsString().NotNullable()
            .WithColumn("password").AsString().NotNullable() |> ignore
    
    override this.Down() =
        this.Delete.Table("users") |> ignore
   

[<Migration(2L, "Adds posts table")>]
type AddPostsTable() =
    inherit Migration()

    override this.Up() =
        this.Create.Table("posts")
            .WithColumn("id").AsInt64().PrimaryKey().Identity()
            .WithColumn("title").AsString().NotNullable()
            .WithColumn("body").AsString().NotNullable() |> ignore
    
    override this.Down() =
        this.Delete.Table("posts") |> ignore