import axios from "axios"
import { boolean } from "zod"

import { enpoints } from "./enpoints"
import { ArtWork, Creator } from "./types"

export async function getCreator(slug: string) {
  const response = await axios.get<Creator>(enpoints.getCreator(slug))
  return response.data
}

export async function getArwork(idArtwork: string) {
  const response = await axios.get<ArtWork>(enpoints.getArtwork(idArtwork))
  return response.data
}

export async function deleteArwork(idArtwork: string) {
  const request = await axios.delete(enpoints.deleteArtwork(idArtwork))
  const response = request.status

  return response === 204
}
