# ArtLite API
- [ArtLite Api](#buber-breakfast-api)
  - [Get Creator](#get-creator)
    - [Get Creator Request](#get-creator-request)
    - [Get Creator Response](#get-creator-response)
  - [Create Artwork](#create-artwork)
    - [Create Artwork Request](#create-artwork-request)
    - [Create Artwork Response](#create-artwork-response)
  - [Get Artwork](#get-artwork)
    - [Get Artwork Request](#get-artwork-request)
    - [Get Artwork Response](#get-artwork-response)
  - [Delete Artwork](#delete-artwork)
    - [Delete Artwork Request](#delete-artwork-request)
    - [Delete Artwork Response](#delete-artwork-response)
  - [Get Tag List](#get-tag-list)
    - [Get Tag List Request](#get-tag-list-request)
    - [Get Tag List Response](#get-tag-list-response)

## Get Creator

### Get Creator Request

```js
GET /api/creators/:idCreator
```

### Get Creator Response

```js
200 Ok
```

```json
{
    "idCreator": "00000000-0000-0000-0000-000000000000",
    "username": "Sebastian Cavazzoli",
    "slug": "sebastian_cavazzoli",
    "email": "sebas@gmail.com",
    "highlightedPhrase?": "3D Character Artist",
    "biography?": "3D Character Artist. I have a passion for 3D art. Currently working on my own personal projects!",
    "socials": {
        "instagram?": "https://www.instagram.com/sebacavazzoli.art",
        "youtube?": "https://www.youtube.com/sebastiancavazzoli",
        "facebook?": "",
        "linkedin?": "",
        "figma?": ""
    },
    "profileImage?": "https://cdna.artstation.com/p/users/avatars/000/583/624/large/21ab51c6fdec0656327acd1decc6b95f.jpg?1521491898",
    "profileBanner?": "https://cdna.artstation.com/p/users/covers/000/583/624/default/73c0b86e24cfe09e6954896a1b24b5c0.jpg?1687826140",
    "artworks": [
        {
            "idArtwork": "00000000-0000-0000-0000-000000000000",
            "title": "3D Character",
            "thumbnail": "https://cdnb.artstation.com/p/assets/images/images/070/397/485/20231212212844/smaller_square/sebastian-cavazzoli-2313313.jpg?1702438125",
            "createdAt": "2023-08-02T23:46:06.1367502"
        },
        {
            "idArtwork": "00000000-0000-0000-0000-000000000000",
            "title": "Pirate",
            "thumbnail": "https://cdnb.artstation.com/p/assets/images/images/064/384/223/smaller_square/sebastian-cavazzoli-1.jpg?1687806929",
            "createdAt": "2023-05-29T07:19:57.9192814"
        }
    ],
    "createdAt": "2023-12-15T01:39:50.8766667",
    "updatedAt": "2023-12-22T01:13:53.73"
}
```


## Create Artwork

### Create Artwork Request

```js
POST /api/artworks
```

```yml
Content-Type: multipart/form-data
```

```json
{
    "title": "Goblins",
    "description?": "3D character that I've been working to be part of Globant Game Studio's Portfolio.",
    "tags": [
        "Digital 2D",
        "Fantasy",
        "Concept Art",
        "Storytelling"
    ],
    "images": [
        { "file": "(binary data)" },
        { "file": "(binary data)" },
        { "file": "(binary data)" },
        { "file": "(binary data)" }
    ]
}
```

### Create Artwork Response

```js
201 Created
```

```yml
Location: {{host}}/api/artworks/{{id}}
```

```json
{
    "idArtwork": "00000000-0000-0000-0000-000000000000",
    "title": "Goblins",
    "description?": "3D character that I've been working to be part of Globant Game Studio's Portfolio.",
    "tags": [
        "Digital 2D",
        "Fantasy",
        "Concept Art",
        "Storytelling"
    ],
    "images": [
        { "order": 1, "src": "https://cdnb.artstation.com/p/assets/images/images/037/967/575/large/sebastian-cavazzoli-1b.jpg?1621815282" },
        { "order": 2, "src": "https://cdna.artstation.com/p/assets/images/images/037/967/578/large/sebastian-cavazzoli-3.jpg?1621815288" },
        { "order": 3, "src": "https://cdna.artstation.com/p/assets/images/images/037/967/552/large/sebastian-cavazzoli-4.jpg?1621815193" },
        { "order": 4, "src": "https://cdna.artstation.com/p/assets/images/images/037/967/556/large/sebastian-cavazzoli-6.jpg?1621815211" },
    ],
    "creator": {
        "idCreator": "00000000-0000-0000-0000-000000000000",
        "username": "Sebastian Cavazzoli",
        "slug": "sebastian_cavazzoli",
        "profileImage": "https://cdna.artstation.com/p/users/avatars/000/583/624/large/21ab51c6fdec0656327acd1decc6b95f.jpg?1521491898",
    },
    "createdAt": "2023-10-24T09:02:25.8272588",
    "updatedAt": "2023-12-22T01:15:51.173"
}

```

## Get Artwork

### Get Artwork Request

```js
GET /api/artworks/{{id}}
```

### Get Artwork Response

```js
200 Ok
```

```json
{
    "idArtwork": "00000000-0000-0000-0000-000000000000",
    "title": "Goblins",
    "description?": "3D character that I've been working to be part of Globant Game Studio's Portfolio.",
    "tags": [
        "Digital 2D",
        "Fantasy",
        "Concept Art",
        "Storytelling"
    ],
    "images": [
        { "order": 1, "src": "https://cdnb.artstation.com/p/assets/images/images/037/967/575/large/sebastian-cavazzoli-1b.jpg?1621815282" },
        { "order": 2, "src": "https://cdna.artstation.com/p/assets/images/images/037/967/578/large/sebastian-cavazzoli-3.jpg?1621815288" },
        { "order": 3, "src": "https://cdna.artstation.com/p/assets/images/images/037/967/552/large/sebastian-cavazzoli-4.jpg?1621815193" },
        { "order": 4, "src": "https://cdna.artstation.com/p/assets/images/images/037/967/556/large/sebastian-cavazzoli-6.jpg?1621815211" },
    ],
    "creator": {
        "idCreator": "00000000-0000-0000-0000-000000000000",
        "username": "Sebastian Cavazzoli",
        "slug": "sebastian_cavazzoli",
        "profileImage": "https://cdna.artstation.com/p/users/avatars/000/583/624/large/21ab51c6fdec0656327acd1decc6b95f.jpg?1521491898",
    },
    "createdAt": "2023-10-24T09:02:25.8272588",
    "updatedAt": "2023-12-22T01:15:51.173"
}
```

## Delete Artwork

### Delete Artwork Request

```js
DELETE /api/artworks/{{id}}
```

### Delete Artwork Response

```js
204 No Content
```

## Get Tag List

### Get Tag List Request

```js
GET /api/tags
```

### Get Tag List Response

```js
200 Ok
```

```json
{
    "tags": ["Abstract", "Fantasy", "Nature"]
}
```