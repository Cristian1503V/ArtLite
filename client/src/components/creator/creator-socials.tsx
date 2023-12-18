import Link from "next/link"

import { Icons } from "../icons"

interface CreatorSocialsProps {
  href?: string
  icon: keyof typeof Icons
}

export function CreatorSocials({ href = "#", icon }: CreatorSocialsProps) {
  const Icon = Icons[icon || "thumbsUp"]
  return (
    <Link
      href={href}
      className="bg-muted hover:bg-muted-hover flex h-10 w-10 items-center justify-center rounded-full p-2 transition-all"
    >
      <Icon className="h-5 w-5" />
    </Link>
  )
}
