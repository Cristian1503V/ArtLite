import { notFound } from "next/navigation"
import { getCreator } from "@/api/actions"

import { Aside } from "@/components/aside"
import { Creations } from "@/components/creator/creations"
import { ProfileInformation } from "@/components/creator/profile-information"

interface CreatorPageProps {
  params: {
    slug: string
  }
}

async function getData(slugCreator: string) {
  try {
    return await getCreator(slugCreator)
  } catch (error) {
    return undefined
  }
}

export default async function CreatorPage({ params }: CreatorPageProps) {
  const { slug } = params
  const creator = await getData(slug)

  if (!creator) notFound()

  return (
    <div className="relative flex h-full w-full flex-1 gap-6 px-6">
      <Creations creator={creator} />
      <Aside>
        <ProfileInformation creator={creator} />
      </Aside>
    </div>
  )
}
