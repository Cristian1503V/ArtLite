import { env } from "@/config/env"

export const enpoints = {
  getCreator: (slung: string) => `${env.api}/creators/${slung}`,
  getArtwork: (idArtwork: string) => `${env.api}/artworks/${idArtwork}`,
  deleteArtwork: (idArtwork: string) => `${env.api}/artworks/${idArtwork}`,
}
