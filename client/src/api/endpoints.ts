import { env } from "@/config/env"

export const endpoints = {
  getCreator: (slung: string) => `${env.api}/creators/${slung}`,
  getArtwork: (idArtwork: string) => `${env.api}/artworks/${idArtwork}`,
  deleteArtwork: (idArtwork: string) => `${env.api}/artworks/${idArtwork}`,
  getTags: `${env.api}/tags`,
  createArtwork: `${env.api}/artworks`,
}
