import { env } from "@/config/env"

export const enpoints = {
  getCreator: (slung: string) => `${env.api}/creators/${slung}`,
}
