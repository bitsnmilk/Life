module Domain

open System

type Post = {
    Id: int
    Tite : string
    Description : string
    Body : string
    CreatedAt : DateTime
    UpdatedAt : DateTime
}