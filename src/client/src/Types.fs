module Types

open System

type UserData = {
    Username : string
    Token : String
}

type Post = {
    Id: int
    Title : string
    Description : string
    Body : string
    CreatedAt : DateTime
    UpdatedAt : DateTime
}