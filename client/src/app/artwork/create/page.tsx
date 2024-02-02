import React from "react"
import { getTags } from "@/api/actions"

import { ArtworkCreateForm } from "@/components/forms/artwork-create-form"

async function getData() {
  try {
    return await getTags()
  } catch (error) {
    console.log({})
    return undefined
  }
}

export default async function CreateArtwok() {
  const data = await getData()

  return (
    <div className="flex h-full w-full flex-1 justify-center px-10">
      <div className="container">
        <ArtworkCreateForm tags={data?.tags} />
      </div>
    </div>
  )
}
