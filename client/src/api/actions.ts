import axios from "axios"

import { enpoints } from "./enpoints"
import { Creator } from "./types"

export async function getCreator(slug: string) {
  const response = await axios.get<Creator>(enpoints.getCreator(slug))
  return response.data
}
