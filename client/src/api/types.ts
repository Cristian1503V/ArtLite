export type Creator = {
  idCreator: string
  slug: string
  username: string
  email: string
  highlightedPhrase?: string
  biography?: string
  socials: Socials
  profileImage?: string
  profileBanner?: string
  artworks: ArtworkBase[]
  createdAt: Date
  updatedAt: Date
}

export type Socials = {
  instagram?: string
  youtube?: string
  facebook?: string
  linkedin?: string
  figma?: string
}

export type User = {
  idUSer: string
  userName: string
  profileImage: string
  bio: string
  email: string
  createdAt: Date
}

export type ArtWorkThumbnail = ArtworkBase & {
  creator: Pick<Creator, "idCreator" | "username" | "profileImage">
}

type ArtworkBase = {
  idArtwork: string
  title: string
  thumbnail: string
  createdAt: Date
}
