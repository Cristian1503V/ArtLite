import Link from "next/link"
import { User } from "@/api/types"

import { ButtonLink } from "./button-link"
import { AppIcon } from "./icons"

interface HeaderAuthProps {
  user?: Pick<User, "profileImage" | "userName">
}

export function HeaderAuth({ user }: HeaderAuthProps) {
  return (
    <header className="bg-background sticky top-0 z-50 flex h-16 w-full items-center justify-between px-9 py-8">
      <Link href={"/"} className="h-8 w-9">
        <AppIcon />
      </Link>
      {user ? (
        <div>{user.userName}</div>
      ) : (
        <div className="flex items-center justify-center gap-4">
          <ButtonLink
            href="#"
            variant="secondary"
            icon="pencil"
            className="px-4"
          >
            Sign up
          </ButtonLink>
          <ButtonLink href="#" icon="logIn" className="px-4">
            Sign In
          </ButtonLink>
        </div>
      )}
    </header>
  )
}
