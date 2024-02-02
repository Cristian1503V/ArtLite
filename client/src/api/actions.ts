"use server"

import { rejects } from "assert"
import { resolve } from "path"
import axios from "axios"

import { endpoints } from "./endpoints"
import { ArtWork, Creator, TagsResponse } from "./types"

export async function getCreator(slug: string) {
  const response = await axios.get<Creator>(endpoints.getCreator(slug))
  return response.data
}

export async function getArwork(idArtwork: string) {
  const response = await axios.get<ArtWork>(endpoints.getArtwork(idArtwork))
  return response.data
}

export async function getTags() {
  const response = await axios.get<TagsResponse>(endpoints.getTags)
  return response.data
}

export async function createArtwork(body: FormData) {
  return new Promise(async (resolve, reject) => {
    try {
      const request = await axios.post(endpoints.createArtwork, body)
      const response = request.status
      if (response === 201) {
        resolve("created")
      } else {
        reject()
      }
    } catch {
      reject()
    }
  })
}

export async function deleteArwork(idArtwork: string) {
  return new Promise(async (resolve, reject) => {
    try {
      const request = await axios.delete(endpoints.deleteArtwork(idArtwork))
      const response = request.status
      if (response === 204) {
        resolve("deleted")
      } else {
        reject()
      }
    } catch {
      reject()
    }
  })
}
