module Migrations

open FluentMigrator


type Builders.Create.Table.ICreateTableColumnOptionOrWithColumnSyntax with
    member x.WithCreatedAt() =
        x.WithColumn("created_at").AsDateTime2().NotNullable().WithDefault(SystemMethods.CurrentDateTime)

    member x.WithModifiedAt() =
        x.WithColumn("modified_at").AsDateTime2().NotNullable().WithDefault(SystemMethods.CurrentDateTime)

type Builders.Create.Table.ICreateTableWithColumnOrSchemaOrDescriptionSyntax with
    member x.WithIdentityColumn() = x.WithColumn("id").AsInt64().PrimaryKey().Identity()

    member x.WithCreatedAt() =
        x.WithColumn("created_at").AsDateTime2().NotNullable().WithDefault(SystemMethods.CurrentDateTime)

    member x.WithModifiedAt() =
        x.WithColumn("modified_at").AsDateTime2().NotNullable().WithDefault(SystemMethods.CurrentDateTime)

[<Migration(1L, "Adds base schema")>]
type AddUserTable() =
    inherit Migration()

    override this.Up() =
        this.Create.Table("users")
            .WithIdentityColumn()
            .WithColumn("username").AsFixedLengthString(60).NotNullable()
            .WithColumn("password").AsFixedLengthString(64).NotNullable()
            .WithColumn("email").AsFixedLengthString(60).NotNullable()
            .WithColumn("email_is_valid").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("user_enabled").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("bio").AsString().Nullable()
            .WithCreatedAt().WithModifiedAt() |> ignore

        this.Create.Table("posts")
            .WithIdentityColumn()
            .WithColumn("user_id").AsInt64().NotNullable()
            .WithColumn("title").AsFixedLengthString(60).NotNullable()
            .WithColumn("slug").AsFixedLengthString(60).NotNullable()
            .WithColumn("description").AsFixedLengthString(150)
            .WithColumn("post_type").AsInt16().NotNullable()
            .WithColumn("markdown").AsString().Nullable()
            .WithColumn("html").AsString().Nullable()
            .WithColumn("body").AsString().Nullable()
            .WithColumn("javascript").AsString().Nullable()
            .WithCreatedAt().WithModifiedAt() |> ignore



    override this.Down() =
        this.Delete.Table("users") |> ignore
        this.Delete.Table("posts") |> ignore
