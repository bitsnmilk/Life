module Types

open System

type Post = {
    Id: int
    Title : string
    Description : string
    Body : string
    CreatedAt : DateTime
    UpdatedAt : DateTime
}