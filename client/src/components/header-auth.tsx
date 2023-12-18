import Link from "next/link"
import { User } from "@/api/types"

import { ButtonLink } from "@/components/button-link"
import { AppIcon, Icons } from "@/components/icons"

interface HeaderAuthProps {
  user?: Pick<User, "profileImage" | "userName">
}

export function CardWrapper({ user }: HeaderAuthProps) {
  const Icon = Icons["upload"]

  return (
    <header className="bg-background sticky top-0 z-50 flex h-16 w-full items-center justify-between px-7 py-5">
      <Link href={"/"}>
        <AppIcon />
      </Link>

      <div className="flex items-center justify-center gap-4">
        <Link
          href={"/artwork/create"}
          className="bg-muted hover:bg-muted-hover p- rounded-md p-[9px] leading-3 transition-all"
        >
          <Icon className="h-4 w-4" />
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
      </div>
    </header>
  )
}
