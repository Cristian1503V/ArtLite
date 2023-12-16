"use client"

import React, { useCallback } from "react"
import { cn } from "@/libs/utils"
import { DevTool } from "@hookform/devtools"
import { zodResolver } from "@hookform/resolvers/zod"
import { DropEvent, FileRejection, useDropzone } from "react-dropzone"
import {
  Control,
  Controller,
  FieldValues,
  FormProvider,
  useFieldArray,
  useForm,
} from "react-hook-form"
import * as z from "zod"

import { zodValidations } from "@/config/zod-validate"

import { DropArea } from "../drop-area"
import { Icons } from "../icons"
import { PreviewImage } from "../preview-image"
import TitleWrapper from "../title-wrapper"

const formSchema = z.object({
  title: zodValidations.validateString({ maxLength: 30, minLength: 4 }),
  description: zodValidations.validateString({ maxLength: 30, minLength: 4 }),
  images: z
    .any()
    .refine((files) => files.length > 0, "Se requiere al menos una imagen"),
})

export type FormSchema = z.infer<typeof formSchema>

// type DropType = <T extends File>(
//   acceptedFiles: T[],
//   fileRejections: FileRejection[],
//   event: DropEvent
// ) => void

export function ArtworkCreateForm() {
  const methods = useForm<FormSchema>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      title: "Hola como estas",
      description: "hdsfhghdsfghghdsjghjdshfghsdjk",
      images: [],
    },
    mode: "onBlur",
  })

  const {
    register,
    handleSubmit,
    watch,
    control,
    setValue,
    formState: { errors },
  } = methods

  const onSubmit = (dataForm: FormSchema) => {
    console.log({ dataForm })
  }

  const watchTitle = watch("title")

  return (
    <div className="h-full  w-full">
      <h2 className="line-clamp-1 w-[500px] overflow-hidden px-4 text-[30px]">
        {watchTitle === "" ? "Untitled" : watchTitle}
      </h2>
      <FormProvider {...methods}>
        <form onSubmit={handleSubmit(onSubmit)} className="flex">
          <div className="flex h-full w-[75%] basis-[100%] flex-col">
            <TitleWrapper title="Artwork Title">
              <input
                className={cn(
                  "bg-input text-foreground border-input-border rounded-md border-[1px] px-3 py-2 text-sm focus:outline-none",
                  errors.title && "border-red-400"
                )}
                type="text"
                {...register("title")}
                placeholder="What is your artwork called?"
              />

              <input
                className={cn(
                  "bg-input text-foreground border-input-border rounded-md border-[1px] px-3 py-2 text-sm focus:outline-none",
                  errors.description && "border-red-400"
                )}
                type="text"
                {...register("description")}
                placeholder="What is your artwork called?"
              />

              {errors.description && (
                <span className="text-xs text-red-400">
                  {errors.description.message}
                </span>
              )}

              {errors.title && (
                <span className="text-xs text-red-400">
                  {errors.title.message}
                </span>
              )}
            </TitleWrapper>

            {/* <div className="flex w-full flex-col  gap-8 px-4 py-6">
              <section
                className={cn(
                  "flex w-full cursor-pointer flex-col gap-6 rounded-md border-[2px] border-dashed border-[#303034] px-2 pb-20 transition-all",
                  (isDragAccept || isFocused) &&
                    "border-accent-hover bg-[#303034] opacity-50",
                  isDragReject && "border-red-400 bg-[#303034] opacity-50"
                )}
                {...getRootProps({})}
              >
                <div className="border-b border-[#303034] py-2">
                  <div className="flex w-28 flex-col border-r border-[#303034] pr-2 ">
                    <div className="hover:bg-muted flex cursor-pointer flex-col items-center justify-center rounded-md py-4 transition-all">
                      <input
                        className="hidden"
                        {...getInputProps()}
                        {...register("images")}
                        // onChange={onChange}
                        // onChange={(event) => {
                        //   onChange(event.target.files[0])
                        // }}
                        // ref={ref}
                      />
                      <Icons.image className="text-accent" />
                      <span className="text-[14px] font-bold">HQ Images</span>
                      <span className="text-secondary-foreground text-[12px]">
                        JPG,JPEG,PNG
                      </span>
                    </div>
                  </div>
                </div>

                <div className="z-30 py-11">
                  <input className="hidden" {...getInputProps()} />
                  <div className="flex w-full items-center justify-center">
                    <span className="hover:bg-muted flex cursor-pointer gap-2 rounded-md border border-[#303034] px-3 py-2 text-[14px] transition-all">
                      <Icons.image className="text-accent h-5 w-5" />
                      Upload Media Files
                    </span>
                  </div>
                </div>
              </section>

              <aside className="grid gap-5 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-3">
                {watch("images").map((file) => {
                  const preview = URL.createObjectURL(file)
                  const adsa = { ...file, preview }

                  return <PreviewImage key={file.name} file={adsa} />
                })}
              </aside>
            </div> */}

            <DropzoneField control={control} name="images" />

            <DevTool control={control} />

            {errors.images && (
              <span className="text-xs text-red-400">
                {errors.images.message}
              </span>
            )}
          </div>

          <div className="w-[25%]">
            <TitleWrapper title="Publishing Options">
              <span className="text-secondary-foreground text-[14px]">
                Publish status
              </span>
              <button
                className="text-accent-foreground  bg-accent hover:bg-accent-hover flex items-center justify-center gap-2 rounded-lg px-2 py-[10px] text-[14px] font-semibold leading-3 transition-all"
                type="submit"
              >
                <Icons.rocket className="h-5 w-5" />
                <span>Publish</span>
              </button>
            </TitleWrapper>
          </div>
        </form>
      </FormProvider>
    </div>
  )
}

const DropzoneField = ({
  name,
  control,
  ...rest
}: {
  name: string
  control: Control<FieldValues>
}) => {
  // const { control } = useFormContext();

  return (
    <Controller
      render={({ field: { onChange } }) => (
        <Dropzone
          onChange={(e: any) => onChange(e.target.files[0])}
          {...rest}
        />
      )}
      name={name}
      control={control}
      defaultValue=""
    />
  )
}

const Dropzone = ({
  onChange,
  ...rest
}: {
  onChange: (...event: any[]) => void
}) => {
  const onDrop = useCallback((acceptedFiles) => {
    // Do something with the files
    console.log({ acceptedFiles })
  }, [])
  const { getRootProps, getInputProps, isDragActive } = useDropzone({ onDrop })
  return (
    <div {...getRootProps()}>
      <input {...getInputProps({ onChange })} />
      {isDragActive ? (
        <p>Drop the files here ...</p>
      ) : (
        <p>Drag n drop some files here, or click to select files</p>
      )}
    </div>
  )
}

// "use client"

// import React, { useCallback } from "react"
// import { cn } from "@/libs/utils"
// import { DevTool } from "@hookform/devtools"
// import { zodResolver } from "@hookform/resolvers/zod"
// import { DropEvent, FileRejection, useDropzone } from "react-dropzone"
// import {
//   Control,
//   Controller,
//   FieldValues,
//   FormProvider,
//   useFieldArray,
//   useForm,
// } from "react-hook-form"
// import * as z from "zod"

// import { zodValidations } from "@/config/zod-validate"

// import { DropArea } from "../drop-area"
// import { Icons } from "../icons"
// import { PreviewImage } from "../preview-image"
// import TitleWrapper from "../title-wrapper"

// const formSchema = z.object({
//   title: zodValidations.validateString({ maxLength: 30, minLength: 4 }),
//   description: zodValidations.validateString({ maxLength: 30, minLength: 4 }),
//   images: z
//     .any()
//     .refine((files) => files.length > 0, "Se requiere al menos una imagen"),
// })

// export type FormSchema = z.infer<typeof formSchema>

// // type DropType = <T extends File>(
// //   acceptedFiles: T[],
// //   fileRejections: FileRejection[],
// //   event: DropEvent
// // ) => void

// export function ArtworkCreateForm() {
//   const methods = useForm<FormSchema>({
//     resolver: zodResolver(formSchema),
//     defaultValues: {
//       title: "Hola como estas",
//       description: "hdsfhghdsfghghdsjghjdshfghsdjk",
//       images: [],
//     },
//   })

//   const {
//     register,
//     handleSubmit,
//     watch,
//     control,
//     setValue,
//     formState: { errors },
//   } = methods

//   // const onDrop = useCallback(
//   //   (droppedFiles: FileList) => {
//   //     setValue("images", droppedFiles, { shouldValidate: true })
//   //   },
//   //   [setValue]
//   // )
//   // const {
//   //   getRootProps,
//   //   getInputProps,
//   //   isDragActive,
//   //   isDragAccept,
//   //   isDragReject,
//   //   isFocused,
//   // } = useDropzone({
//   //   onDrop,
//   //   accept: { "image/*": [] },
//   // })

//   const onSubmit = (dataForm: FormSchema) => {
//     console.log({ dataForm })
//   }

//   const watchTitle = watch("title")

//   return (
//     <div className="h-full  w-full">
//       <h2 className="line-clamp-1 w-[500px] overflow-hidden px-4 text-[30px]">
//         {watchTitle === "" ? "Untitled" : watchTitle}
//       </h2>
//       <FormProvider {...methods}>
//         <form onSubmit={handleSubmit(onSubmit)} className="flex">
//           <div className="flex h-full w-[75%] basis-[100%] flex-col">
//             <TitleWrapper title="Artwork Title">
//               <input
//                 className={cn(
//                   "bg-input text-foreground border-input-border rounded-md border-[1px] px-3 py-2 text-sm focus:outline-none",
//                   errors.title && "border-red-400"
//                 )}
//                 type="text"
//                 {...register("title")}
//                 placeholder="What is your artwork called?"
//               />

//               <input
//                 className={cn(
//                   "bg-input text-foreground border-input-border rounded-md border-[1px] px-3 py-2 text-sm focus:outline-none",
//                   errors.description && "border-red-400"
//                 )}
//                 type="text"
//                 {...register("description")}
//                 placeholder="What is your artwork called?"
//               />

//               {errors.description && (
//                 <span className="text-xs text-red-400">
//                   {errors.description.message}
//                 </span>
//               )}

//               {errors.title && (
//                 <span className="text-xs text-red-400">
//                   {errors.title.message}
//                 </span>
//               )}
//             </TitleWrapper>

//             {/* <div className="flex w-full flex-col  gap-8 px-4 py-6">
//               <section
//                 className={cn(
//                   "flex w-full cursor-pointer flex-col gap-6 rounded-md border-[2px] border-dashed border-[#303034] px-2 pb-20 transition-all",
//                   (isDragAccept || isFocused) &&
//                     "border-accent-hover bg-[#303034] opacity-50",
//                   isDragReject && "border-red-400 bg-[#303034] opacity-50"
//                 )}
//                 {...getRootProps({})}
//               >
//                 <div className="border-b border-[#303034] py-2">
//                   <div className="flex w-28 flex-col border-r border-[#303034] pr-2 ">
//                     <div className="hover:bg-muted flex cursor-pointer flex-col items-center justify-center rounded-md py-4 transition-all">
//                       <input
//                         className="hidden"
//                         {...getInputProps()}
//                         {...register("images")}
//                         // onChange={onChange}
//                         // onChange={(event) => {
//                         //   onChange(event.target.files[0])
//                         // }}
//                         // ref={ref}
//                       />
//                       <Icons.image className="text-accent" />
//                       <span className="text-[14px] font-bold">HQ Images</span>
//                       <span className="text-secondary-foreground text-[12px]">
//                         JPG,JPEG,PNG
//                       </span>
//                     </div>
//                   </div>
//                 </div>

//                 <div className="z-30 py-11">
//                   <input className="hidden" {...getInputProps()} />
//                   <div className="flex w-full items-center justify-center">
//                     <span className="hover:bg-muted flex cursor-pointer gap-2 rounded-md border border-[#303034] px-3 py-2 text-[14px] transition-all">
//                       <Icons.image className="text-accent h-5 w-5" />
//                       Upload Media Files
//                     </span>
//                   </div>
//                 </div>
//               </section>

//               <aside className="grid gap-5 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-3">
//                 {watch("images").map((file) => {
//                   const preview = URL.createObjectURL(file)
//                   const adsa = { ...file, preview }

//                   return <PreviewImage key={file.name} file={adsa} />
//                 })}
//               </aside>
//             </div> */}

//             <DropzoneField control={control} name="images" />

//             <DevTool control={control} />

//             {errors.images && (
//               <span className="text-xs text-red-400">
//                 {errors.images.message}
//               </span>
//             )}
//           </div>

//           <div className="w-[25%]">
//             <TitleWrapper title="Publishing Options">
//               <span className="text-secondary-foreground text-[14px]">
//                 Publish status
//               </span>
//               <button
//                 className="text-accent-foreground  bg-accent hover:bg-accent-hover flex items-center justify-center gap-2 rounded-lg px-2 py-[10px] text-[14px] font-semibold leading-3 transition-all"
//                 type="submit"
//               >
//                 <Icons.rocket className="h-5 w-5" />
//                 <span>Publish</span>
//               </button>
//             </TitleWrapper>
//           </div>
//         </form>
//       </FormProvider>
//     </div>
//   )
// }

// const DropzoneField = ({
//   name,
//   control,
//   ...rest
// }: {
//   name: string
//   control: Control<FieldValues>
// }) => {
//   // const { control } = useFormContext();

//   return (
//     <Controller
//       render={({ field: { onChange } }) => (
//         <Dropzone
//           onChange={(e: any) => onChange(e.target.files[0])}
//           {...rest}
//         />
//       )}
//       name={name}
//       control={control}
//       defaultValue=""
//     />
//   )
// }

// const Dropzone = ({
//   onChange,
//   ...rest
// }: {
//   onChange: (...event: any[]) => void
// }) => {
//   const onDrop = useCallback((acceptedFiles) => {
//     // Do something with the files
//     console.log({ acceptedFiles })
//   }, [])
//   const { getRootProps, getInputProps, isDragActive } = useDropzone({ onDrop })
//   return (
//     <div {...getRootProps()}>
//       <input {...getInputProps({ onChange })} />
//       {isDragActive ? (
//         <p>Drop the files here ...</p>
//       ) : (
//         <p>Drag n drop some files here, or click to select files</p>
//       )}
//     </div>
//   )
// }
