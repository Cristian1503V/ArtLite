import React from "react"

import { ArtworkCreateForm } from "@/components/forms/artwork-create-form"

export default function CreateArtwok() {
  return (
    <div className="flex h-full w-full flex-1 justify-center">
      <div className="container">
        <ArtworkCreateForm />
      </div>
    </div>
  )
}
