import { notFound } from "next/navigation"
import { getCreator } from "@/api/actions"

import AsideCreator from "@/components/aside-creator"
import CardWrapper from "@/components/card-wrapper"
import Creations from "@/components/creations"
import ProfileInformation from "@/components/profile-information"

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
    <div className="relative flex h-full w-full gap-6 px-6">
      <Creations creator={creator} />
      <AsideCreator>
        <ProfileInformation creator={creator} />
      </AsideCreator>
    </div>
  )
}
