import React from "react"
import { Metadata } from "next"

import { HeaderAuth } from "@/components/header-auth"

export const metadata: Metadata = {
  title: "ArtLite - Home",
  description: "",
}

export default function Creatorlayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <div className="bg-background flex  min-h-screen flex-col">
      <HeaderAuth />
      {children}
    </div>
  )
}
