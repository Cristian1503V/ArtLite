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
  - [Update Artwork](#update-artwork)
    - [Update Artwork Request](#update-artwork-request)
    - [Update Artwork Response](#update-artwork-response)
  - [Delete Artwork](#delete-artwork)
    - [Delete Artwork Request](#delete-artwork-request)
    - [Delete Artwork Response](#delete-artwork-response)


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
    "idCreator": "",
    "username": "Sebastian Cavazzoli",
    "email": "sebas@gmail.com",
    "highlightedPhrase?": "3D Character Artist",
    "biography?": "3D Character Artist. I have a passion for 3D art. Currently working on my own personal projects!",
    "socials": {
        "instagram?": "",
        "youtube?": "",
        "facebook?": "",
        "linkedin?": "",
        "figma?": ""
    },
    "profileImage?": "https://cdna.artstation.com/p/users/avatars/000/583/624/large/21ab51c6fdec0656327acd1decc6b95f.jpg?1521491898",
    "profileBanner?": "",
    "artworks": [
        {
            "idArtwork": "",
            "title": "",
            "thumbnail": "",
            "createdAt": ""
        },
        {
            "idArtwork": "",
            "title": "",
            "thumbnail": "",
            "createdAt": ""
        }
    ],
    "createdAt": "",
    "updatedAt": "",
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
    "title": "Glober",
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
    "idArtwork": "",
    "title": "",
    "description?": "",
    "tags": ["Digital 3D", "Concept Art"],
    "images": [
        { "order": 1, "src": "img1.jpg" },
        { "order": 2, "src": "img2.jpg" },
        { "order": 3, "src": "img3.jpg" },
        { "order": 4, "src": "img4.jpg" },
    ],
    "creator": {
        "idCreator": "",
        "username": "Sebastian Cavazzoli",
        "profileImage": "https://cdna.artstation.com/p/users/avatars/000/583/624/large/21ab51c6fdec0656327acd1decc6b95f.jpg?1521491898",
    },
    "createdAt": "",
    "updatedAt": ""
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
    "idArtwork": "",
    "title": "",
    "description?": "",
    "tags": ["Digital 3D", "Concept Art"],
    "images": [
        { "order": 1, "src": "img1.jpg" },
        { "order": 2, "src": "img2.jpg" },
        { "order": 3, "src": "img3.jpg" },
        { "order": 4, "src": "img4.jpg" },
    ],
    "creator": {
        "idCreator": "",
        "username": "Sebastian Cavazzoli",
        "profileImage": "https://cdna.artstation.com/p/users/avatars/000/583/624/large/21ab51c6fdec0656327acd1decc6b95f.jpg?1521491898",
    },
    "createdAt": "",
    "updatedAt": ""
}
```

## Update Artwork

### Update Artwork Request

```js
PUT /api/artworks/{{id}}
```

```json
{
    "title": "Glober",
    "description?": "3D character that I've been working to be part of Globant Game Studio's Portfolio.",
    "tags": [
        "Digital 2D",
        "Fantasy",
        "Concept Art",
        "Storytelling"
    ]
}
```

### Update Artwork Response

```js
200 Ok
```

```json
{
    "idArtwork": "",
    "title": "",
    "description?": "",
    "tags": ["Digital 3D", "Concept Art"],
    "images": [
        { "order": 1, "src": "img1.jpg" },
        { "order": 2, "src": "img2.jpg" },
        { "order": 3, "src": "img3.jpg" },
        { "order": 4, "src": "img4.jpg" },
    ],
    "creator": {
        "idCreator": "",
        "username": "Sebastian Cavazzoli",
        "profileImage": "https://cdna.artstation.com/p/users/avatars/000/583/624/large/21ab51c6fdec0656327acd1decc6b95f.jpg?1521491898",
    },
    "createdAt": "",
    "updatedAt": ""
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
