interface PortraitProps {
  src: string
  name: string
}

export function Portrait({ src, name }: PortraitProps) {
  return (
    <div className="overflow-hidde flex h-full w-full items-center justify-center">
      <div className="flex justify-center">
        <img
          src={src}
          alt={name}
          className="max-h-[calc(100vh-80px)] object-cover px-0 xl:px-0 2xl:px-11 "
        />
      </div>
    </div>
  )
}
